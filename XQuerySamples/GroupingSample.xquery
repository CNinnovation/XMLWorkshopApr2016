xquery version "3.1";
for $country in distinct-values(doc("racers.xml")//Racer/Country)
let $racers := doc("racers.xml")//Racer[Country=$country]
order by $country
return <country name="{$country}" >
	{ 
		for $racer in $racers
		order by $racer/Wins descending
		return 
		<racer>
			<firstname>{$racer/Firstname/text()}</firstname>
			<lastname>{$racer/Lastname/text()}</lastname>
		</racer>

	}
</country>

