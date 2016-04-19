using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ozeki.Media.MediaHandlers;
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;
using System.Text.RegularExpressions;
using System.Threading;

namespace OLPL_API_Server.Controllers
{
    
    public class CallPatronItemPickupController : ApiController
    {
        string message;
        string id2;
        ISoftPhone softphone;   // softphone object
        IPhoneLine phoneLine;   // phoneline object
        IPhoneCall call;
        static MediaConnector connector;
        static PhoneCallAudioSender mediaSender;
        int done = 0;
        public string Get(string id)
        {
            Regex regexObj = new Regex(@"[^\d]");
            id2 = regexObj.Replace(id, "");
            softphone = SoftPhoneFactory.CreateSoftPhone(5000, 10000);
            var registrationRequired = true;
            var userName = "730";
            var displayName = "730";
            var authenticationId = "730";
            var registerPassword = "";
            var domainHost = "192.168.60.225";
            var domainPort = 5060;
            var account = new SIPAccount(registrationRequired, displayName, userName, authenticationId, registerPassword, domainHost, domainPort);
            RegisterAccount(account);
            mediaSender = new PhoneCallAudioSender();
            connector = new MediaConnector();
            int count = 0;
            while (done == 0 && count < 120) { count++; Thread.Sleep(1000); }
            return message;
        }
        void RegisterAccount(SIPAccount account)
        {
            try
            {
                phoneLine = softphone.CreatePhoneLine(account);
                phoneLine.RegistrationStateChanged += line_RegStateChanged;
                softphone.RegisterPhoneLine(phoneLine);
            }
            catch (Exception ex)
            {
                message = "Error during SIP registration: " + ex;
            }
        }
        void line_RegStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            if (e.State == RegState.NotRegistered || e.State == RegState.Error)
                message = ("Registration failed!");

            if (e.State == RegState.RegistrationSucceeded)
            {
                message = ("Registration succeeded - Online!");
                CreateCall();
            }
        }
        void CreateCall()
        {
            var numberToDial = id2;
            call = softphone.CreateCallObject(phoneLine, numberToDial);
            call.CallStateChanged += call_CallStateChanged;
            call.Start();
        }
        void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            message = "Call state: " +  e.State;

            if (e.State == CallState.Answered)
            {
                try
                {
                    TextToSpeech  TTS = new TextToSpeech();

                    mediaSender.AttachToCall(call);
                    connector.Connect(TTS, mediaSender);
                    TTS.AddAndStartText("Hello World!");
                    //call.BlindTransfer("**13000");
                    //message = "Transfered";
                }
                catch(Exception e1) { message = e1.ToString(); }
            }
            if (e.State == CallState.InCall)
            {
                message = "InCall";
            }
            if (e.State == CallState.Transferring)
            {
                message = "Transferring";
            }
            if (e.State == CallState.Ringing)
            {
                message = "Ringing";
            }
            if (e.State == CallState.Completed)
            {
                message = "Completed";
                done =1;
            }
                
        }
    }
}
