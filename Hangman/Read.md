

## Hangman

### Overblik  
Et simpelt konsolspil lavet i C#, hvor du spiller Hangman.  
Du skal gætte bogstaver for at finde det skjulte ord.  

Spillet har blandt andet:  
- Forskellige sværhedsgrader (Let, Mellem, Svær)  
- En hangman-tegning, der bliver tegnet linje efter linje, når du gætter forkert  
- En oversigt over alfabetet, så du kan se hvilke bogstaver du har brugt  
- Hjerter, der viser hvor mange liv du har tilbage  
- Mulighed for at spille igen, når runden er slut  

## Filer  
### program.cs.cs  
Styrer hele spillet
### Game.cs  
Styrer spil logikken.Kalder på Status og Word klassen

### Word.cs  
Indeholder ordlisterne  

### Status.cs  
Står for alt det visuelle i konsollen.  Tegner header, hangman, hjerter, alfabet og resten af spilvisningen.  


## Flow

```text
Start
    |
Vælg sværhedsgrad
    |
Find et tilfældigt ord
    |
Gæt et bogstav
    |
Er det korrekt?
    |-- Nej --> Mist et liv
    |           (et hjerte forsvinder, og Hangman bliver tegnet)
    |
    |-- Ja --> Tilføj bogstavet til secretArray
                |
                |-- Hvis der er liv tilbage --> Gæt næste bogstav
                |
                |-- Hvis ordet er gættet / ingen liv tilbage
                        |
                        Spil igen?
                        |-- Ja --> Start forfra
                        |-- Nej --> Slut
```


## Validering  
Du må kun skrive bogstaver og 0 (ingen symboler eller andre tal).  
Hvis du skriver flere bogstaver på én gang, tager spillet kun det første.  

***

