from io import StringIO
import token
import sys
import tokenize


def iter_group(obj, n):
    return zip(*([iter(obj)] * n))


tokens = []
for line in sys.argv[1:]:
    with StringIO(line) as io_line:
        tokens.append([
            i.string for i in tokenize.tokenize(lambda: bytes(io_line.readline(), 'utf-8')) if
            not (i.type in [token.NEWLINE, token.INDENT, token.DEDENT, token.ENCODING])
        ])

for user, akey in iter_group(tokens, 2):
    if user == akey:
        print("1")
    else:
        print("0")
