# hps-csharp-nunit

[![Build Status](https://travis-ci.org/hiptest/hps-csharp-nunit.svg?branch=master)](https://travis-ci.org/hiptest/hps-csharp-nunit)

Hiptest publisher samples with C#/NUnit

In this repository you'll find tests generated in C#/NUnit format from [Hiptest](https://hiptest.net), using [Hiptest publisher](https://github.com/hiptest/hiptest-publisher).

The goals are:

 * to show how tests are exported in C#/NUnit.
 * to check exports work out of the box (well, with implemented actionwords)

System under test
------------------

The SUT is a (not that much) simple coffee machine. You start it, you ask for a coffee and you get it, sometimes. But most of times you have to add water or beans, empty the grounds. You have an automatic expresso machine at work or at home? So you know how it goes :-)

Update tests
-------------

To update the tests:

    hiptest-publisher -c nunit.conf --only=tests

The tests are generated in the [``tests``](https://github.com/hiptest/hps-csharp-nunit/tree/master/tests) directory.

Run tests
---------

To build the project and run the tests, use the following command:

    xbuild nunit.csproj
    xbuild nunit.csproj /t:test

The SUT implementation can be seen in [``tests/class/CoffeeMachine.cs``](https://github.com/hiptest/hps-csharp-nunit/tree/master/tests/class/CoffeeMachine.cs)

The test report is generated in ```TestResult.xml```


Run it on Linux Debian
----------------------

You need at least Mono 3.10 to run them. If you do not have Mono installed on
your OS, the easiest way I found is to use a recent mono docker image.

```
# pull Mono 3.10
docker pull mono:3.10

# run it and bind current directory to /opt/hps-csharp
docker run -i -t -v $(pwd):/opt/hps-csharp mono:3.10 /bin/bash
```

You are now running inside the docker mono image. Use the following commands
to run the tests

```
# install needed mono libraries
nuget install NUnit -Version 2.6.4
nuget install NUnit.Runners -Version 2.6.4

# build
cd /opt/hps-csharp
xbuild nunit.csproj

# test
xbuild nunit.csproj /t:test
```

Once you have finished with the mono image, you can list the containers and
delete those you do not use anymore.

```
# list all containers
docker ps -a

# delete a container
docker rm <container id>
```