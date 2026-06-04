

#  Hangman 

## Overview  
A simple console‑based Hangman game written in C#.  
The player guesses letters to reveal a hidden word.  
Features include:

Difficulty levels (Easy, Medium, Hard)  
- Hangman drawing that updates with mistakes  
- Alphabet display showing guessed letters  
- Hearts showing remaining lives  
- Option to play again  


## Flowchart

```text
Start
    |
Choose difficultylevel
    |
Picks random word
    |
User Guess letter
    |
Correct? -- No -- Lose life(fade heart and build hangman)
    | Yes          |
Reveal letter -- Game over? -- No -- Guess next letter
                            | Yes
                       Guessed word 
                            |
                       [Play again?] → Yes → [Start]
                            | No
                            End
```

##  Files   

### **Game.cs**
- Main game loop  
- Input validation  
- switch for difficulty  
- do‑while for replay  
- Calls Status and Word  

### **Word.cs**
- Word lists  
- Dictionary with difficulty levels  
- Returns random word  

### **Status.cs**
- Draws header  
- Draws hangman  
- Draws hearts  
- Draws alphabet  
- Draws main section  





##    validation
only letters  and 0 are allowerd(no symbols or other numbers) , even if user types multiple letters , game considers only the first letter 




