using System;
using System.Collections.Generic;


namespace CustomNamespace
{
    public class CustomClass
    {
        public object Run()
        {
            string pronounsRaw = "$targetuseralejopronouns";
            string targetName = "$targetuserdisplayname";
            string targetUrl = "$targetuserurl";
            string targetGame = "$targetuserstreamgame";
            bool isLive = "$targetuserstreamislive" == "True";

            // Add new category verbs as desired in the { "category", "verb" }, format
            var verbDict = new Dictionary<string, string>
            {
                { "Art", "making" },
                { "Special Events", "celebrating" },
                { "Makers & Crafting", "doing" },
                { "Lego & Brickbuilding", "doing" },
                { "Science & Technology", "doing" },
                { "Travel & Outdoors", "doing" },
                { "Food & Drink", "making" },
                { "Just Chatting", "" },
                { "Software and Game Development", "doing" }
            };

            // Map each subject pronoun to a suitable object pronoun
            var pronounsDict = new Dictionary<string, string>
            {
                { "He", "him" },
                { "She", "her" },
                { "Xe", "xem" },
                { "Ze", "zir" },
                { "Fae", "faer" },
                { "Ve", "ver" },
                { "It", "it" },
                { "Ey", "em" },
                { "Per", "per" },
                { "Ae", "aer" },
                { "E", "em" },
                { "Zie", "hir" }
            };

            string subject = pronounsRaw.Split('/')[0];

            string subjectPronoun = pronounsDict.ContainsKey(subject)
                ? subject.ToLower()
                : "they";
            string objectPronoun = pronounsDict.ContainsKey(subject)
                ? pronounsDict[subject]
                : "them";

            // Use the correct tense - update to taste
            string tense;
            if (subjectPronoun == "they")
            {
                tense = isLive ? "are live RIGHT NOW" : "were last";
            }
            else
            {
                tense = isLive ? "is live RIGHT NOW" : "was last";
            }

            // Adjust the verb based on the target game - fall back to "playing"
            string verb = verbDict.ContainsKey(targetGame) ? verbDict[targetGame] : "playing";

            string messageTemplate = "Go follow {0} and show {1} some love at {2} ! {3} {4} {5} {6}.";

            // Add arguments to the message template
            string message = string.Format(messageTemplate, targetName, objectPronoun, targetUrl, subjectPronoun, tense, verb, targetGame);

            return message;
        }
    }
}
