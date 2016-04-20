xquery version "3.1";

declare function local:one()
  as xs:decimal? {
		   42
  };

declare function local:two()
  as xs:decimal? {
		   43
  };

let $a := local:one()
let $b := local:two()
return $a





