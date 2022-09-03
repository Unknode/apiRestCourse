using System.Collections.Generic;

namespace ApiRest.Data.Converter.Contract
{
    public interface IParser <S, D>
    {
        D Parse(S source);
        List<D> Parse(List<S> source);
    }
}
