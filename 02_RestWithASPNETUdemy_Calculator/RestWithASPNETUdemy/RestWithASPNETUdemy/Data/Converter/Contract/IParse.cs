using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.Converter.Contract
{
    //interface de origem e destino
    public interface IParse <O,D>
    {
        D Parse(O origem);

        List<D> Parse(List<O> origem);
    }
}
