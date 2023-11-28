# CS2-PlayersBet
CSSharp plugin to allow players to bet on the next winning team.

# Install
- Requires CSSharp and metamod installed on your server
- Extract the zip file to your `csgo` folder
- Execute `css_plugins list` on your server to check the install
- You might have to `css_plugins load PlayersBet` on the first install (or restart the server)

# Usage
- Type !bet or /bet to invoke the command
- Usage is: `!bet <ct|t> <all|half|amount>`
  > team must be `ct` or `t`
  > amount can be `all` for all you money, `half` for half your money or any number between 0 and your current amount of money.
- You can not bet if all players of a team are dead.

# Infos
- Bet earnings are calculated as such:
  > 4 CTs vs 2 Ts
  > you have $5,000
  > !bet t all
  > You bet $5,000 on the Terrorists, if they win, you win your bet * (4 / 2) = $10,000
  > You also get back your bet => $5,000
  > You have $15,000 on the next round.

# Known issues:
- CSSharp is working on UserMessages, in the meantime, I can not refresh the money displayed in the HUD
  
- CSSharp has an issue causing some event not to be triggered until a hot-reload has been done
  > Run `css_plugins reload PlayerBet` to fix the issue
