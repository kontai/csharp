namespace GenesisLib
{
    public class Point
    {
        private double x;
        private double y;
        private double x_max;
        private double x_min;
        private double y_max;
        private double y_min;

        public Point(double x=0, double y=0, double x_min=0, double x_max=0, double y_min=0, double y_max=0)
        {
            this.x = x;
            this.y = y;
            this.x_min = x_min;
            this.x_max = x_max;
            this.y_min = y_min;
            this.y_max = y_max;
        }

        // Properties
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double XMax
        {
            get { return x_max; }
            set { x_max = value; }
        }
        public double XMin
        {
            get { return x_min; }
            set { x_min = value; }
        }
        public double YMax
        {
            get { return y_max; }
            set { y_max = value; }
        }
        public double YMin
        {
            get { return y_min; }
            set { y_min = value; }
        }
        // Methods
        public override string ToString()
        {
            return $"Point(X: {x}, Y: {y}, XMin: {x_min}, XMax: {x_max}, YMin: {y_min}, YMax: {y_max})";
        }

        public bool IsWithinBounds()
        {
            return x >= x_min && x <= x_max && y >= y_min && y <= y_max;
        }

        public void Reset()
        {
            x = 0;
            y = 0;
            x_min = 0;
            x_max = 0;
            y_min = 0;
            y_max = 0;
        }

        public void SetBounds(double x_min, double x_max, double y_min, double y_max)
        {
            this.x_min = x_min;
            this.x_max = x_max;
            this.y_min = y_min;
            this.y_max = y_max;
        }

    }
}