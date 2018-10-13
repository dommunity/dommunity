TESTS = tests

lib_LTLIBRARIES = libdommunity.la
libdommunity_la_SOURCES = node/seed_nodes.cpp
libdommunity_la_CPPFLAGS = -I$(top_builddir)/include $(BOOST_CPPFLAGS)
libdommunity_la_LDFLAGS = -version-info 0:0:0 $(BOOST_LDFLAGS)

check_PROGRAMS = tests
tests_CPPFLAGS = -I$(top_builddir)/include -DBOOST_TEST_DYN_LINK $(BOOST_CPPFLAGS)
tests_LDADD = libdommunity.la $(BOOST_UNIT_TEST_FRAMEWORK_LIB)
tests_LDFLAGS = $(BOOST_LDFLAGS)
tests_SOURCES = \
	dommunity.tests.cpp \
	node/seed_nodes.tests.cpp
