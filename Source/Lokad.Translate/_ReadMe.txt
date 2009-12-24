Lokad.Translate

A web-based utility tool, to speed-up the translation process.

TODO for v1.0:
- upgrade lib using Lokad.Data.dll
http://sites.google.com/a/lokad.com/dev/Home/release-information/lokad-internal-1-3
(caution: NHibernate config need a fix as well)

- upgrade NHibernate toward the Linq interface (much cleaner and compact).

- repository implementations need review (newbie at NHibernate)

POSTPONED

- minimal polish for CSS (Lokad colors + logo)

- multi-tenancy + admin setup (needed to create the first user)
==> Caution: in case of multi-tenant, a single translator may belong to multiple account!

- performance is awful (=> don't care for prototype)
- improve dates display

- improve ActionLink with strong typed call to controllers
http://haacked.com/archive/0001/01/01/how-a-method-becomes-an-action.aspx
(when it becomes available)

IDEA:
- add wiki syntax conversion GoogleCode => CodePlex (as a side utility)
