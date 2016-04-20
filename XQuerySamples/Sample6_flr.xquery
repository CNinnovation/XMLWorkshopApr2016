xquery version "1.0";

let $wins := 30

for $racer at $i in doc("Racers.xml")//Racer[Wins > $wins]
let $name := $racer/Firstname/text() 
return <Racer>{ $i } . { $name } </Racer>
