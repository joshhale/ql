class C {
  m() {}
}

class D extends C {
  constructor() {
    super(); // OK
  }
}

let c = new C(); // OK
C();             // NOT OK
new (x=>x);      // NOT OK
c.m();           // OK
new c.m();       // NOT OK

var o = {
  f: function() {},
  g() {}
};
o.f();           // OK
new o.f();       // OK
o.g();           // OK
new o.g();       // NOT OK

function f(b) {
  var g;
  if (b)
    g = class {};
  else
    g = (() => {});
  console.log();
  if (!b)
    g();         // OK
  else
    new g();     // OK
}

function* g() {}
async function h() {}

new g()          // NOT OK
new h()          // NOT OK

C.call();        // NOT OK
C.apply();       // NOT OK

//semmle-extractor-options: --experimental
