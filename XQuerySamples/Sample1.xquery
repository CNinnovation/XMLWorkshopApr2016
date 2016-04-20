xquery version "1.0";

(: first sample - loading a document, access and return Racer elements based on a condition :)
doc("racers.xml")/Racers/Racer[Wins > 25]
