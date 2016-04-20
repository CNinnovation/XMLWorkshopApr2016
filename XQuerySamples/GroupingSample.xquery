xquery version "3.1";

(: group racers by country :)

for $country in distinct-values(doc("racers.xml")//Racer/Country)
let $racers := doc("racers.xml")//Racer[Country=$country]
let $wins :=  sum($racers/Wins/text())
order by $wins descending, $country
return <country name="{$country}" wins="{$wins}" >
	{ 
		for $racer in $racers
		order by $racer/Wins descending
		return 
			<racer>
				<firstname>{$racer/Firstname/text()}</firstname>
				<lastname>{$racer/Lastname/text()}</lastname>
				<wins>{number($racer/Wins/text())}</wins>
			</racer>
	}
</country>

