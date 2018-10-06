#include <dommunity/node/seed_nodes.hpp>

using namespace dommunity::node;

std::vector<std::string> const &seed_nodes()
{
	static std::vector<std::string> const nodes = {
		"127.0.0.1"
	};

	return nodes;
}
