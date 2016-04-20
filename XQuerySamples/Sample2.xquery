xquery version "1.0";

for $racer in doc("racers.xml")/Racers/Racer
where $racer/Wins > 30
order by $racer/Wins
return $racer/Firstname