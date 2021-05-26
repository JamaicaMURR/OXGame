using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public delegate void IntEvent(int value);
public delegate float RawProvider();
public delegate void RawConsumer(float raw);
