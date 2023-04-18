using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadTest.Models
{
    public enum ServiceOptions
    {
        None,
        Bespoke,
        Professional
    }

    public enum OrientationOptions
    {
        None,
        Landscape,
        Portrait
    }

    public enum TemplateOptions
    {
        None,
        Plain,
        Stripe,
        Watermark
    }

    public enum PrintOnReverseOptions
    {
        None,
        BlackColour,
        FullColour
    }
    public enum MagStripeEncodingOptions
    {
        None,
        MagStripe,
        MagStripeEncoding
    }
}