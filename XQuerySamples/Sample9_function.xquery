xquery version "1.0";

declare function local:wins(
  $wins as xs:decimal?)
  as xs:string? {
    let $x := "kickoff"
	   return 
		   if ($wins > 20)
		   then "MANY wins"
		   else "not so many wins"
  };


for $racer in doc("racers.xml")/Racers/Racer
let $winsmessage := concat(' ', local:wins( $racer/Wins ))
return 
<Racer>
  <Name> { $racer/Firstname/text() } </Name>
  <Message> { local:wins($racer/Wins) } </Message>
</Racer>