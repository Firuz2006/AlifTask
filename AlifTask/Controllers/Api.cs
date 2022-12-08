using Microsoft.AspNetCore.Mvc;
using SMSSender;
using SMSSender.Models;

namespace AlifTask.Controllers;

public class Api : Controller
{
    public object Index(Properties model)
    {
        try
        {

        
        if (model.Diapason!=9 && model.Diapason!=12 && model.Diapason!=18 && model.Diapason!=24)
        {
            return BadRequest();
        }

        var smsSender = new SmsSender();
        switch (model.Product)
        {
            case Products.Smartphone:
                switch (model.Diapason)
                {
                    case 12:
                        model.Price += model.Price * 3 / 100;
                        break;
                    case 18:
                        model.Price += model.Price * 6 / 100;
                        break;
                    case 24:
                        model.Price += model.Price * 9 / 100;
                        break;
                }

                break;
            case Products.Computer:
                switch (model.Diapason)
                {
                    case 18:
                        model.Price += model.Price * 3 / 100;
                        break;
                    case 24:
                        model.Price += model.Price * 6 / 100;
                        break;
                }

                break;
            case Products.Television:
                if (model.Price == 24)
                {
                    model.Price += model.Price * 3 / 100;
                }

                break;
        }

        smsSender.Send(model);
        return model;
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}