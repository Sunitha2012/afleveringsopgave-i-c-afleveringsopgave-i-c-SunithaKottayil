

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

***

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
Er det korrekt? -- Nej -- Mist et liv (et hjerte forsvinder, og hangman bliver tegnet)
        | Ja
Afslør bogstavet
    |
Er spillet slut? -- Nej -- Gæt igen
            | Ja
      Ordet er fundet
            |
    Spil igen?
        | Ja → Start forfra
        | Nej → Slut
```

***

## Filer  

### Game.cs  
Styrer selve spillet.  
Her kører hovedloopet, input bliver tjekket, og spilleren vælger sværhedsgrad.  
Der er også en do-while, så man kan spille igen.  
Kalder på Status og Word.  

### Word.cs  
Indeholder ordlisterne.  
Bruger en dictionary til sværhedsgrader og vælger et tilfældigt ord.  

### Status.cs  
Står for alt det visuelle i konsollen.  
Tegner header, hangman, hjerter, alfabet og resten af spilvisningen.  

***

## Validering  
Du må kun skrive bogstaver og 0 (ingen symboler eller andre tal).  
Hvis du skriver flere bogstaver på én gang, tager spillet kun det første.  

***

