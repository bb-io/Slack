import json

with open('all_emojis.json', encoding='utf-8') as fh:
  data = json.load(fh)

unique = set()
with open('output.txt', 'w', encoding='utf-8') as fh:
  for emoji in data:
    emoji_str = ''.join([chr(int(x.zfill(8), 16)) for x in emoji['unified'].split('-')])
    fh.write(f"{{ \"{emoji['short_name']}\", \"{emoji_str} {emoji['name'].title()}\" }},\n")