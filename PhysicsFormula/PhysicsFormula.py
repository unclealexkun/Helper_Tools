import math

def calculate_N_exp(B, B0, a, b, l):
    db = (B - B0) * 10 ** -3
    l = l * 0.5
    s = math.sqrt(math.pi / (a * b * 10 ** -6))
    r = db/(l * s * B0 * 10 ** -3)
    return r

def calculate_N_inf(a, b, l):
    k = 2 / math.pi

    ra = 4 / ( l * 10 ** -3)
    raa = ra * math.sqrt((a * b * 10 ** -6) / math.pi)

    rb = (l * 10 ** -3) / (4 * math.pi)
    rbb = math.sqrt(math.pi / (a * b * 10 ** -6))
    rbbb = (16 * a * b * 10 ** -6) / (math.pi * math.pow(l * 10 ** -3, 2))
    rbbbb = math.log(1 + rbbb)

    r = k * math.atan(raa) - rb * rbb * rbbbb
    return r

def calculate_N_end(a, b, l):
    ka = math.sqrt(a * b * 10 ** -6) - math.sqrt(math.pi * math.pow(l * 10 ** -3, 2))
    kb = math.sqrt((16 * a * b * 10 ** -6) + math.pi * math.pow(l * 10 ** -3, 2))
    rc = (ka * kb) / (4 * math.pi * a * b * 10 ** -6)

    rd = 0.144 * l * 10 ** -3
    re = (a * l * 10 ** -6) / math.sqrt(math.pow(b * 10 ** -3, 3) * a * 10 ** -3)
    rf = - (l * 10 ** -3) / (80 * math.sqrt(a * b * 10 ** -6))
    fg = math.pow(b * 10 ** -3, rf)

    r = 1 / (rc + rd * re * fg)
    return r

print("Рассчёт N эксп:")

print("a = ", end = "")
a = float(input())
print("b = ", end = "")
b = float(input())

for i in range(0, 11):
    print(i + 1,")")
    print("l = ", end = "")
    l = float(input())
    print("B = ", end = "")
    B = float(input())
    print("B0 = ", end = "")
    B0 = float(input())
    print("N = ", calculate_N_exp(B, B0, a, b, l))

print("Рассчёт N беск:")
for i in range(0, 11):
    print(i + 1,")")
    print("l = ", end = "")
    l = float(input())
    print("N = ", calculate_N_inf(a, b, l))

print("Рассчёт N кон:")
for i in range(0, 11):
    print(i + 1,")")
    print("l = ", end = "")
    l = float(input())
    print("N = ", calculate_N_end(a, b, l))

