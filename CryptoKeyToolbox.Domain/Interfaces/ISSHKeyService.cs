using CryptoKeyToolbox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyToolbox.Domain.Interfaces
{
    public interface ISSHKeyService
    {
        List<SSHKeyPair> GenerateKeys(int bits = 2048, int count = 1);

    }
}
