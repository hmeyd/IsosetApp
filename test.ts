type opp = (a: number, b: number) => number;
const addition: opp = (a, b) => a + b;
const resultat = addition(2, 3);
console.log(resultat); // 5
