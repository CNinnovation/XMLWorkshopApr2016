xquery version "1.0";

let $wins := 30

for $racer in doc("Racers.xml")//Racer
where $racer/Wins > $wins
order by $racer/Wins descending, $racer/Lastname
return <Racer> { $racer/Firstname } </Racer>
