
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
    "Lego & Brickbuilding": "doing"
    }

# Display double pronouns properly
if pronounsRaw == "She/They":
    pronounsRaw = "She/Her"
if pronounsRaw == "He/They":
    pronounsRaw = "He/Him"

if "/" in pronounsRaw:
    pronouns = pronounsRaw.lower().split("/")
else:
    pronouns = ['they', 'them']

# Use the correct tense - update to taste
if pronouns[0] == 'they':
    if isLive:
        tense = "are live now"
    else:
        tense = "were last"
else:
    if isLive:
        tense = "is live now"
    else:
        tense = "was last"

# Adjust the verb based on the target game - fall back to "playing"
verb = verbDict.get(targetGame, "playing")

# Edit flavour text to taste! pronouns[0] is he/she/they, pronouns[1] is him/her/them
print(f"Go follow {targetName} and show {pronouns[1]} some love at {targetUrl} !,"
      f"{pronouns[0]} {tense} {verb} {targetGame}.")
