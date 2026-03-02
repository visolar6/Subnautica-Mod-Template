# Subnautica Mod Testing Instructions

Automated testing is very limited for Subnautica mods, as most features depend on UnityEngine and in-game behavior that cannot be unit-tested outside the game. You can technically write unit tests for non-Unity functions, but this will usually cover only a small portion (5-10%) of typical mod code. Manual in-game testing is the standard workflow. Automated or AI-driven in-game testing is not currently possible.
