INCLUDE GLOBALS.ink


=== Begin ===
Bartender: Hey you! What brings you here? 
* [Cocky] Player: Your mother. 
    -> MakeEnemies
* [Friendly] Player: I'm looking for fun. 
    -> MakeFriends

=== MakeEnemies ===
#function HatePlayer:Lady Madlen; #hello world
Bartender: You motherfucker! Get outta here!
+ [Go away] Player: Bye!
    ~ next_dialogue = "MakeEnemies"
  -> END
+ [Be rude] Player: Say hello to mommy from me
    ~ next_dialogue = "MakeEnemies"
  -> END

=== MakeFriends ===
Bartender: I'm afraid you won't find what you're looking for... But even so, you should be happy. After all, you're alive, right?  Well, if you're curious, there have been some strange events in the vicinity lately. People have reported seeing glowing lights in the forest at night and hearing mysterious whispers. Some even claim to have encountered supernatural beings.
* [Inquire] Player: I saw that... Do you know where it comes from? 
    -> Inquire
* [Not interested] I am not interested 
    ~ next_dialogue = "Begin"
  -> END

=== Inquire ===
Bartender: It's hard to say what's causing it... But rumors suggest that there's an ancient artifact hidden deep within the forest, which is said to have magical powers. Some believe these events are connected to that artifact.
* [Explore] Player: I think I'll check it out. Any tips?
    -> Explore
* [Other questions] Player: Tell me more about the tavern.
    -> OtherQuestions

=== Explore ===
Bartender: If you're brave enough, venture into the forest during the night. The glowing lights seem to be more prominent then. But be cautious, for the forest is treacherous and the whispers can lead you astray.
* [Other questions] Player: It's good to know... What else have you got for me?
    -> OtherQuestions
* [End] I will remember. See you later!
    ~ next_dialogue = "Begin"
    -> END

=== OtherQuestions ===
Bartender: The Rusty Mug has been here for decades. It's seen its fair share of stories and secrets. But right now, the strange happenings in the vicinity have everyone on edge.
-> options

= options
* [Secrets] Player: What kind of secrets are hidden within these walls?
    -> Secrets
* [Customers] Player: Who are the regular customers here? Any interesting characters?
    -> Customers
* [End] I will remember. See you later!
    ~ next_dialogue = "Begin"
    -> END


=== Secrets ===
Bartender: Ah, secrets... There's an underground chamber beneath this tavern, rumored to be connected to the ancient artifact I mentioned earlier. Many believe it holds the key to unraveling the mysteries surrounding this place. Unfortunately, it's locked, and its whereabouts are unknown.
* [Other questions] -> OtherQuestions.options
* [Artifact] Player: Tell me more about this ancient artifact. What is it exactly?
    -> Artifact
* [End] I will remember. See you later!
    ~ next_dialogue = "Begin"
    -> END

=== Artifact ===
Bartender: Legends speak of a relic known as the "Shadowheart." It's said to possess immense power, capable of granting the desires of those who possess it. Some believe it brings blessings, while others fear its corrupting influence. The truth of its nature remains a mystery, but its existence has sparked many conflicts throughout history.
* [Conflicts] -> Conflicts
* [End] I will remember. See you later!
    ~ next_dialogue = "Begin"
    -> END

=== Conflicts ===
Player: You mentioned conflicts surrounding the artifact. Can you tell me more about them?
Bartender: Oh, there have been tales of wars waged, kingdoms toppled, and lives lost in pursuit of the Shadowheart. Its allure has tempted both the noblest and the darkest of souls. Greed, power, and desperation often accompany the search for such ancient artifacts, and the Shadowheart is no exception. It is said to have the ability to corrupt even the most virtuous hearts.
* [Other questions] -> OtherQuestions.options
* [End] I will remember. See you later!
    ~ next_dialogue = "Begin"
    -> END

=== Customers ===
Bartender: Ah, the patrons of the Rusty Mug are an eclectic bunch. We have the mysterious hooded figure who always sits in the darkest corner, whispering to themselves. There's the seasoned adventurer who frequents this place, sharing tales of their exploits over a pint of ale. And then there's the local fortune-teller who claims to have glimpses of the future. Each one has their own story and secrets to uncover.
-> options
    
= options
* [Hooded figure] Player: I'm intrigued by the mysterious hooded figure. What do you know about them? 
    -> HoodedFigure
* [Adventurer] Player: The seasoned adventurer sounds interesting. Have they been on any remarkable quests?
    -> Adventurer
* [Fortune teller] Player: I'm curious about the fortune-teller. What kind of glimpses of the future do they claim to have?
    -> FortuneTeller
* [Other questions] -> OtherQuestions.options

    
= HoodedFigure
Bartender: Not much, I'm afraid. They keep to themselves, rarely engaging in conversation with anyone else. Rumors swirl that they're a master of dark magic, seeking solitude and anonymity. Some believe they're on a personal quest, while others think they're hiding from a troubled past. Regardless, their presence adds an air of mystique to the tavern.
-> options

= Adventurer 
Bartender: Oh, indeed! They've ventured into the depths of ancient ruins, faced off against fearsome creatures, and recovered lost artifacts of great value. Their stories are a tapestry of heroism, danger, and the pursuit of knowledge. Many aspire to follow in their footsteps, while others envy their bravery.
-> options

= FortuneTeller
Bartender: The fortune-teller possesses an uncanny ability to see through the veils of time. They speak of prophecies, foretelling both blessings and tragedies. Some say their predictions have saved lives, while others dismiss them as mere illusions. Nevertheless, many seek their guidance and hope to unravel the mysteries of their own destinies.
-> options

