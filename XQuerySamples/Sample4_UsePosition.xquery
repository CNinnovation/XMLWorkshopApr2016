xquery version "1.0";

for $racer at $i in doc("Racers.xml")//Racer[Wins > 30]
return <Racer>{ $i } . { $racer/Firstname/text() } </Racer>
