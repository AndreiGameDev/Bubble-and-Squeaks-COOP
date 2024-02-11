using System;
using UnityEngine;

public class Easing {
    public static float Linear(float t) {
        return t;
    }
    public class  Sines
    {
        public static float In(float t) {
            return 1f - Mathf.Cos(t * (MathF.PI / 2f));
        }
        public static float Out(float t) {
            return MathF.Sin(t * (MathF.PI / 2f));
        }
        public static float InOut(float t) {
            return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
        }
    }
    public class Cubic {
        public static float In(float t) {
            return t * t * t;
        }
        public static float Out(float t) {
            return 1 - Mathf.Pow(1 - t, 3);
        }
        public static float InOut(float t) {
            if(t < 0.5) {
                return 4f * t * t * t;
            } else {
                return 1f - Mathf.Pow(-2 * t + 2, 3) / 2;
            }
        }
    }
    public class Quint {
        public static float In(float t) {
            return t * t * t * t * t;
        }
        public static float Out(float t) {
            return 1 - Mathf.Pow(1 - t, 5);
        }
        public static float InOut(float t) {
            if (t < 0.5f) {
                return 16 * t * t * t * t * t;
            } else {
                return 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
            }
        }
    }
    public class Elastic {
        public static float In(float t) {
            float c4 = (2 * Mathf.PI) / 3;
            if(t == 0) {
                return 0;
            }
            else if(t == 1) {
                return 1;
            }
            else{
                return -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
            }
        }
        public static float Out(float t) {
            float c4 = (2 * Mathf.PI) / 3;

            if (t == 0) {
                return 0;
            }
            else if(t == 1) {
                return 1;
            }
            else {
                return Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
            }
        }

        public static float InOut(float t) {
            float c5 = (2 * Mathf.PI) / 4.5f;
            if(t == 0) {
                return 0;
            }
            else if(t == 1) {
                return 1;
            }
            else if( t < 0.5f) {
                return -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2;
            } else {
                return Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5) / 2 + 1;
            }
        }
    }
    public class Quadratic {
        public static float In(float t) {
            return t * t;
        }
        public static float Out(float t) {
            return t * (2f - t);
        }
        public static float InOut(float t) {
            if ((t *= 2f) < 1f) return 0.5f * t * t;
            return -0.5f * ((t -= 1f) * (t - 2f) - 1f);
        }
    }
    public class Quart {
        public static float In(float t) {
            return t * t * t * t;
        }
        public static float Out(float t) {
            return 1 - MathF.Pow(1 - t, 4);
        }
        public static float InOut(float t) {
            if(t < 0.5f) {
                return 8 * t * t * t * t;
            } else {
                return 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
            }
        }
    }
    public class Expo {
        public static float In(float t) {
            if(t == 0) {
                return 0;
            } else {
                return Mathf.Pow(2, 10 * t -10);
            }
        }
        public static float Out(float t) {
            if (t == 1) {
                return 1;
            } else {
                return 1 - Mathf.Pow(2, -10 * t);
            }
        }

        public static float InOut(float t) {
            if(t == 0) {
                return 0;
            } else if(t == 1) {
                return 1;
            } else if( t < 0.5) {
                return Mathf.Pow(2, 20 * t - 10) / 2;
            } else {
                return (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
            }
        }
    }
    public class Back {
        public static float In(float t) {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return c3 * t * t * t - c1 * t * t;
        }
        public static float Out(float t) {
                float c1 = 1.70158f;
                float c3 = c1 + 1;

                return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        }

        public static float InOut(float t) {
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;

            if(t < 0.5f) {
                return (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2;
            } else {
                return (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 -2) + c2) + 2) / 2;
            }
        }
    }
    public class Bounce {
        public static float In(float t) {
            return 1 - Out(1 - t);
        }
        public static float Out(float t) {
            float n1 = 7.5625f;
            float d1 = 2.75f;

            if (t < 1 / d1) {
                return n1 * t * t;
            } else if (t < 2 / d1) {
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            } else if (t < 2.5 / d1) {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            } else {
                return n1 * (t -= 2.625f / d1) * t + 0.984375f;
            }
        }
        public static float InOut(float t) {
            if(t < 0.5f) {
                return (1 - Out(1 - 2 * t)) / 2;
            } else{
                return (1 + Out(2 * t - 1)) / 2;
            }
        }
    }
}
