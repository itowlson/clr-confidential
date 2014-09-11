module FSStackTraceTests

let rec factorial i =
  if i = 0I then 1I
  //elif i = 19900I then failwith "THIS IS SPARTA"
  else i * factorial (i-1I)

let rec factorial_ i acc =
  if i = 0I then acc
  //elif i = 17000I then failwith "THIS IS SPARTA"
  else factorial_ (i-1I) (acc * i)