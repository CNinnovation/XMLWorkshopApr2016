xquery version "1.0";

declare function local:wins(
  $wins as xs:decimal?)
  as xs:string? {
		   if ($wins > 20)
		   then "MANY wins"
		   else "not so many wins"
  };


for $racer in doc("racers.xml")/Racers/Racer
return 
<Racer>
  <Name>{ concat( $racer/Firstname/text(), $racer/Lastname/text()) } </Name>
  <Message> { local:wins($racer/Wins) } </Message>
</Racer>