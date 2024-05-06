using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

ushort us = 1365;
byte b = (byte)us; //對於轉換時會丟失精度，c#不提供隱式轉換，需要显示轉換

