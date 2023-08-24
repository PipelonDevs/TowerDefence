INCLUDE GLOBALS.ink
INCLUDE GloomyCity


/*
name: Bartender (Old Ben)
Age: 60
Location: Tavern
Associations: Lady Madlen (daughter)
Story: 
    Old Ben was an extravert through and through, finding his joy in engaging with people from all walks of life. 
    Whether they were weary travelers seeking respite or regulars who considered the tavern a second home, he treated everyone as an old friend. 
    His greatest talent lay in his ability to listen. As patrons shared their stories, he would lean in, his genuine interest evident in the way he hung onto every word.
    
    His daughter had inherited his resourcefulness and his free spirit, qualities he admired and nurtured. 
    He granted her the freedom to explore her interests, always encouraging her to forge her own path.
    However, as any caring parent would, Old Ben couldn't help but worry about her mysteries and shady entourage.
*/ 



VAR is_abstinent = false
VAR previous_drink = ()


-> begin // debug


=== begin 
    - {Player_BartenderKnowledge == 0: -> get_to_know| -> say_hi} // show once
    
    - (conversation)
    - {&-> see_offer| <- take_sip| <- take_sip } // assumes that player drinks during different dialogues
    <- confide
    <- ask
    + [Go away] -> end
    -> DONE

=== end
    // We might want to reset some variables before ending
    -> END


=== say_hi
    Bartender: Welcome back {Player_name}!
    Player: Hi Old Ben!
    -> begin.conversation
    
=== get_to_know 
    Bartender: Hi there, stranger! What brings you here? They call me <b>Old</b> <b>Ben</b>, by the way. {color("You can either.", SHY)} So? How did you find yourself in this decaying village?
    
    + [Mysterious] 
        Player: I'm just travelling through. Nothing special.
        ~ Bartender_Trust -= 2
    
    + [Friendly] 
        Player: I'm just passing through. I heard this place the most cozy in the vicinity.       
        Bartender: No way! You've heard of this dirty hovel? I'm flattered! I've been brewing it for years, you know. Do my best!
    
    - ~ Player_BartenderKnowledge += 5 
        -> begin.conversation

    
=== ask
    + {not gloomy_city} [Investigate]
        Player: TODO
        Bartender: TODO
        ** (gloomy_city) [Gloomy City] 
            Player: What is this place?
            Bartender: Basically. I really don't know. We haven't really thought about that yet.
            ~ Player_GloomyCityKnowledge ++
            ~ LadyMadlen_Trust -= 1 // Why the player cares? 
    - -> begin.conversation
    
=== confide
    + [Confide] 
        Player: TODO
        Bartender: TODO
        -> begin.conversation
        
    + {Player_drunkState > 3} [Truth] 
        Player: The truth is ... TODO
        Bartender: Unbelivable! TODO
        -> begin.conversation

== function print_barley_type()
    {previous_drink == BarleyTypes.two_row: two|six} row
    
    
=== see_offer
    - {is_abstinent: -> abstinent| Bartender: ...Wheat or barley?}
    + [Wheat] 
        Player: Wheat please.
        Bartender: Cheers!
        ~ Player_money -= LIST_VALUE(TavernShop.wheat_beer)
        
    + [Barley] 
        PLayer: Barley please.
        Bartender: The only good option to be made. {previous_drink:Just like previously - {print_barley_type()}?|Two or six row?}
        ~ Bartender_Trust += 1
        ~ Player_money -= LIST_VALUE(TavernShop.barley_beer)
            
            ** {not previous_drink} [Two]
                Player: Two-row please.
                Bartender: Ah, the classic choice, favored by those who appreciate the full embrace of tradition and flavour. A wise decision indeed.
                ~ previous_drink = BarleyTypes.two_row
                
            ** {not previous_drink} [Six] 
                Player: Six-row please.
                Bartender: Opting for the robust and hearty variety, are we? A preference that speaks of a bold palate and an adventurous spirit.
                ~ previous_drink = BarleyTypes.six_row
                
            ** {not previous_drink}[Any]
                Player: Doesn't matter. Just beer.
                Bartender: Putting your faith in the essence of the brew itself, I see. A sentiment that echoes the heart of the tavern's essence. I'll give you two-row.
                ~ previous_drink = BarleyTypes.two_row
            
            ++ {previous_drink} [Yes] 
                Player: Yeah.
                Bartender:
                                      
            ++ {previous_drink} [No] 
                { previous_drink: 
                    - BarleyTypes.two_row: ~ previous_drink = BarleyTypes.six_row
                    - BarleyTypes.six_row: ~ previous_drink = BarleyTypes.two_row
                    }
                Player: Not this time.
                Bartender: Okay. As you wish - {print_barley_type()} barley.
                
                
    + {TavernShop has whiskey} [Whiskey] 
        Player: No time to waste! Give me your special!
        Bartender: Ahh yes! The finest of the finest! 
                               
    + [Lie] 
        Player: {Personally I don't drink... |I'll pass for a while}
        Bartender: Let's assume I believe You... So You tell, you're here for business? 
        ~ is_abstinent = true
    
    - { not is_abstinent: 
        ~ TavernShop +=  TavernShop.whiskey 
        ~ Player_drunkState ++
       } -> begin
    

    - (abstinent) Bartender: Are you still a water drinker?
    + [Yes] 
        Player: Nothing changed.
    
    + [No] 
        Player: I will give a try!
        ~ is_abstinent = false
    - -> begin.conversation


=== take_sip
    + {not is_abstinent} [Take a sip]
        Player: {&I love this one!|Literally the best!}
        Bartender: {&I am glad| Nice to hear that!}
        -> begin.conversation





