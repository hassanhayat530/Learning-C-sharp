using System;
using static System.Console;

class Rectangle {
    (int x, int y) p;
    (int x, int y) q;

    public Rectangle((int x, int y) p, (int x, int y) q) {
        this.p = p;
        this.q = q;
    }

    public (int, int) upperLeft() {
        return p;
    }

    public (int, int) lowerRight() {
        return q;
    }

    public string str() {
        string coordinates = $"{upperLeft()} - {lowerRight()}";
        return coordinates;
    }

    public int perimeter() {
        int l = q.y - p.y;
        int w = q.x - p.x;

        return 2 * (l + w);
    }

    public int area() {
        int l = q.y - p.y;
        int w = q.x - p.x;

        return l * w;
    }

    public bool contains(Rectangle r) {
        if (r.p.x >= p.x && r.p.y >= p.y && r.q.x <= q.x && r.q.y <= q.y) {  // both corners of r in Rectangle
            return true;
        }

        return false;
    }

    public bool overlap(Rectangle r) {
        if (r.q.x <= p.x)
            return false;

        if (r.p.x >= q.x)
            return false;

        if (r.q.y <= p.y)
            return false;

        if (r.p.y >= q.y)
            return false;

        return true;
}


    public Rectangle intersect(Rectangle r) {
        (int x, int y) a = (0, 0);
        (int x, int y) b = (0, 0);

        if (overlap(r)) {
            a.x = Math.Max(p.x, r.p.x);
            a.y = Math.Max(p.y, r.p.y);

            b.x = Math.Min(q.x, r.q.x);
            b.y = Math.Min(q.y, r.q.y);
        }
        return new Rectangle(a, b);
    }

}
