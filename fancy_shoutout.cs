using System;
using System.Collections.Generic;

namespace CustomNamespace
{
    public class CustomClass
    {
        public object Run()
        {
            // Get the pronouns string
            string pronounsRaw = "$targetuseralejopronouns";
            string targetName = "$targetuserdisplayname";
            string targetUrl = "$targetuserurl";
            string targetGame = "$targetuserstreamgame";
            
            // Create a list of pronouns
            List<string> pronouns = new List<string>();

            // make pronouns consistent within message
            if (pronounsRaw == "She/They")
            {
                pronounsRaw = "She/Her";
            }
            if (pronounsRaw == "He/They")
            {
                pronounsRaw = "He/Him";
            }

            // Split the pronouns string at '/' and add both parts to the list in lowercase
            if (pronounsRaw.Contains("/"))
            {
                string[] splitPronouns = pronounsRaw.Split('/');
                pronouns.Add(splitPronouns[0].ToLower());
                pronouns.Add(splitPronouns[1].ToLower());
            }
            else
            {
                pronouns.Add("they");
                pronouns.Add("them");
            }


            // Determine the correct tense based on whether the user is live
            bool isLive = "$targetuserstreamislive".ToLower() == "true";
            string tense;
            if (pronouns[0] == "they")
            {
                tense = isLive ? "are live now" : "were last";
            }
            else
            {
                tense = isLive ? "is live now" : "was last";
            }

            // Adjust the verb based on the target game
            string verb = targetGame.ToLower() == "art" ? "doing" : "playing";

            // Construct the message template
            string messageTemplate = "Go follow {0} and show {1} some love at {2} ! {3} {4} {5} {6}.";

            // Add arguments to the message template
            string message = string.Format(messageTemplate, targetName, pronouns[1], targetUrl, pronouns[0], tense, verb, targetGame);

            return message;
        }
    }
}
