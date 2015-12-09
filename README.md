# hps-csharp

Hiptest publisher samples with C#

# Update tests

```
hiptest-publisher --config nunit.conf --only=tests
```

# Run it on Linux Debian

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
