# libdommunity [![Build Status](https://travis-ci.org/dommunity/dommunity.svg?branch=master)](https://travis-ci.org/dommunity/dommunity)

libdommunity is a cross-platform C++ library for accessing Dommunity network. It contain only Dommunity specific code without any platform-specific code.

## Dependencies

- C++17
- boost 1.67

## Build instructions for *nix

Build and run unit tests:

```sh
./autogen.sh && ./configure && make && make check
```

If you want to install into your system, run:

```sh
sudo make install
```
