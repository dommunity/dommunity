#ifndef DOMMUNITY_CHAIN_CHAIN_HPP_INCLUDED
#define DOMMUNITY_CHAIN_CHAIN_HPP_INCLUDED

#include "storage.hpp"

namespace dommunity::chain {
	class chain final {
	public:
		chain(storage &s) noexcept;
		chain(chain const &) = delete;

		chain &operator=(chain const &) = delete;

	private:
		storage &s;
	};
}

#endif // DOMMUNITY_CHAIN_HPP_INCLUDED
