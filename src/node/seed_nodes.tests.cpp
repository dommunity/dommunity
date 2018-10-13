#include <dommunity/node/seed_nodes.hpp>
#include <boost/test/unit_test.hpp>

BOOST_AUTO_TEST_CASE(seed_nodes_not_empty)
{
	BOOST_TEST(dommunity::node::seed_nodes().size() > 0);
}
