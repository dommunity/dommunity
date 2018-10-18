AC_INIT([libdommunity], [0.1])
AM_INIT_AUTOMAKE([foreign nostdinc subdir-objects -Wall])

AC_CONFIG_MACRO_DIRS([m4])

AC_PROG_CXX
AM_PROG_AR

AX_CXX_COMPILE_STDCXX([17], noext, mandatory)

LT_INIT([disable-static])

AC_CONFIG_FILES([
	Makefile
	include/Makefile
	src/Makefile
])

AC_OUTPUT
