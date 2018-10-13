TESTS = tests

lib_LTLIBRARIES = libdommunity.la
libdommunity_la_SOURCES = node/seed_nodes.cpp
libdommunity_la_CPPFLAGS = -I$(top_builddir)/include
libdommunity_la_LDFLAGS = -version-info 0:0:0

check_PROGRAMS = tests
tests_CPPFLAGS = -I$(top_builddir)/include -DBOOST_TEST_DYN_LINK
tests_LDADD = libdommunity.la -lboost_unit_test_framework
tests_SOURCES = \
	dommunity.tests.cpp \
	node/seed_nodes.tests.cpp
