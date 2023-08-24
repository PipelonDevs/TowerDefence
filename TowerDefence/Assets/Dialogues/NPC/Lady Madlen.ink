INCLUDE GLOBALS.ink
INCLUDE GloomyCity


/*
name: Lady Madlen
Age: 35
Location: Tavern
Associations: Bartender (father)
Story: 
    She helps his father in running the Tavern. 
    She thinks that world is cruel and people are selfish. Especially travelers. No one can't be sure what they are up to. They comes and goes. Like spies. 
    Silently and steadily, she fortifies her standing within the town.
*/



-> begin // debug

=== begin
    - {! -> say_hi}

    + [Break the ice]  -> break_ice
    * [Go away] 
        Player: Bye   
        -> END
        
        
        
        
=== break_ice
    { stopping:
        - Player: What's up?
          Lady Madlen: Fine.
          
        - Player: Are you often here? Do you like beer?
          Lady Madlen: TODO
           
        - Player: Wanna drink?
          Lady Madlen: Sure, why not?
          ~ Player_money -= LIST_VALUE(TavernShop.whiskey)
          ~ LadyMadlen_Sympathy += 2
            
        - Player: I love the atmosphere here...
           Lady Madlen: Yeah...

    }
    ~ LadyMadlen_Sympathy --
    -> begin

=== say_hi
    + [Hi]
        Player: Hi. 
    + [Good evening]
        Player: Good evening, my lady.
    
    - Lady Madlen: ...
    -> begin
    
