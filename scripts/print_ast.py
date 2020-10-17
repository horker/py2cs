import ast
import sys

with open(sys.argv[1], mode='r', encoding='utf-8') as f:
    doc = f.read()

code = ast.parse(doc, mode='exec')

with open(sys.argv[2], mode='w', encoding='utf-8') as f:
    f.write(ast.dump(code))
