// Player data, should be set at the beginning
VAR Player_money = 100
VAR Player_lvl = 1
VAR Player_name = "dupa_123"

{ not Player_money:
    AssertionError: Variable player_money should be set.
}
{ not Player_lvl:
    AssertionError: Variable player_lvl should be set.
}

// Available states and enums
LIST StateThresholds = (none=0),  (satisfactory=5), (sufficient=10), (good=15), (very_good=20), (excellent=25) 

// Player variables
VAR Player_BartenderKnowledge = 0
VAR Player_LadyMadlenKnowledge = 0
VAR Player_GloomyCityKnowledge = 0

VAR Player_drunkState = 0



//// NPC starting Variables

// Bartender:
VAR Bartender_NextDialogue = "begin"
VAR Bartender_Trust = 15

// LadyMadlen
VAR LadyMadlen_NextDialogue = "begin"
VAR LadyMadlen_Trust = 5  
VAR LadyMadlen_Sympathy = 5


//// COLORS
CONST SHY = "\#c0c0c0f0"
CONST DANGER = "red"


//// Helper functions

EXTERNAL color(text, theme)

=== function color(text, theme)
    // this function is for debug purposes only
    // placeholder for applying html color to the text
    ~ return text


=== function number_between(number, bottom, top) 
   ~ return number > LIST_VALUE(bottom) && number < LIST_VALUE(top)

=== function listWithCommas(list, if_empty)
    {LIST_COUNT(list):
    - 2:
        	{LIST_MIN(list)} and {listWithCommas(list - LIST_MIN(list), if_empty)}
    - 1:
        	{list}
    - 0:
			{if_empty}
    - else:
      		{LIST_MIN(list)}, {listWithCommas(list - LIST_MIN(list), if_empty)}
    }

=== function isAre(list)
	{LIST_COUNT(list) == 1:is|are}

=== function came_from(-> x)
	~ return TURNS_SINCE(x) == 0

    

    
    
    
    
    

