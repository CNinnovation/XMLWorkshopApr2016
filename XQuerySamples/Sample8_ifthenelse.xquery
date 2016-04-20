xquery version "1.0";

for $racer in doc("racers.xml")//Racer
return
if ($racer/Country = "Austria")
then <AustrianRacer> { $racer/Firstname } </AustrianRacer>
else <Racer> { $racer/Firstname } </Racer>