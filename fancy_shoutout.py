
pronounsRaw = "$targetuseralejopronouns"
targetName = "$targetuserdisplayname"
targetUrl = "$targetuserurl"
targetGame = "$targetuserstreamgame"
isLive = "$targetuserstreamislive" == "True"

# Add new category verbs as desired in the "category": "verb", format 
verbDict = {
    "Art": "making",
    "Special Events": "celebrating",
    "Makers & Crafting": "doing",
    "Lego & Brickbuilding": "doing",
    "Science & Technology": "doing",
    "Travel & Outdoors": "doing",
    "Food & Drink": "making",
    "Just Chatting": "",
    "Software and Game Development": "doing"
    }

# Map each primary pronoun to a pair to use in the message
pronouns_dict = {
    "He": ["he", "him"],
    "She": ["she", "her"],
    "Xe": ["xe", "xem"],
    "Ze": ["ze", "zir"],
    "Fae": ["fae", "faer"],
    "Ve": ["ve", "ver"],
    "It": ["it", "it"],
    "Ey": ["ey", "em"],
    "Per": ["per", "per"],
    "Ae": ["ae", "aer"],
    "E": ["e", "em"],
    "Zie": ["zie", "hir"]
}

subject, object = pronouns_dict.get(pronounsRaw.split("/")[0], ["they", "them"])

# Use the correct tense - update to taste
if subject == 'they':
    if isLive:
        tense = "are live RIGHT NOW"
    else:
        tense = "were last"
else:
    if isLive:
        tense = "is live RIGHT NOW"
    else:
        tense = "was last"

# Adjust the verb based on the target game - fall back to "playing"
verb = verbDict.get(targetGame, "playing")

# Edit flavour text to taste! pronouns[0] is he/she/they, pronouns[1] is him/her/them
print(f"Go follow {targetName} and show {object} some love at {targetUrl} ! "
      f"{subject} {tense} {verb} {targetGame}.")
