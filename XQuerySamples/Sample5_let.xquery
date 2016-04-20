xquery version "1.0";

for $i in (1 to 5)
let $j := i + 3
return <test> { $j } </test>
