#include <dommunity/node/seed_nodes.hpp>

std::vector<std::string> const &dommunity::node::seed_nodes()
{
	static std::vector<std::string> const nodes = {
		"127.0.0.1"
	};

	return nodes;
}
