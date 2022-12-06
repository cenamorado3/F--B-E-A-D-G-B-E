//sequences with discriminated unions and record types

type Number = //public by default
    | Even of int//has an 'Is{Type?} = IsEven: bool by default???????
    | Odd of int
    
let n = Even(2)
//n.Dump() // ->See IsEven/IsOdd?

//it knows its type is seq<Number> 
let set = seq {
                for i in -3..10 do
                    yield Odd(i)
                //could do the logic here but that would be to simple, lets! over complicate things
            }

let UnwrapOdd(Odd o) = o

let odds = seq { 
    for s in set do
        let odd = match s with //can you pattern matching here since they are all the same type
                | Odd o -> o % 2 <> 0
                | Even e -> e % 2 = 0
        if(odd) then
            yield s
    }
    
let evens = seq { 
    for s in set do
        let odd = match s with //can you pattern matching here since they are all the same type
                | Odd o -> o % 2 <> 0
                | Even e -> e % 2 = 0
        if not odd then
            yield Even(UnwrapOdd(s))
    }
        
        
let res = seq{odds;evens}
res.Dump()//wierd immutability/mutability?
