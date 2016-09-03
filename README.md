[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/AerisG222/NImgmin/blob/master/LICENSE.md)
[![NuGet](https://buildstats.info/nuget/NImgmin)](https://www.nuget.org/packages/NImgmin/)
[![Travis](https://img.shields.io/travis/AerisG222/NImgmin.svg?maxAge=2592000)](https://travis-ci.org/AerisG222/NImgmin)
[![Coverity Scan](https://img.shields.io/coverity/scan/10073.svg)](https://scan.coverity.com/projects/aerisg222-nimgmin)

# NImgmin

A .Net library to wrap the functionality of imgmin.

## Using
- Follow process to build imgmin here: https://github.com/rflynn/imgmin
- Add a reference to NImgmin in your project.json
- Bring down the packages for your project via `dnu restore`

```csharp
using NImgmin;

namespace Test
{
    public class Example
    {
        public void Minimize(string file, string outfile)
        {
            var imgmin = new Imgmin(new ImgminOptions());
            imgmin.Minify(file, outfile);
        }
    }
}
```

- View the tests for more examples


## Contributing
I'm happy to accept pull requests.  By submitting a pull request, you
must be the original author of code, and must not be breaking
any laws or contracts.

Otherwise, if you have comments, questions, or complaints, please file
issues to this project on the github repo.

## License
NImgmin is licensed under the MIT license.  See LICENSE.md for more
information.

## Reference
- imgmin: https://github.com/rflynn/imgmin
