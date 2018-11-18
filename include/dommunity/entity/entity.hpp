#ifndef DOMMUNITY_ENTITY_ENTITY_HPP_INCLUDED
#define DOMMUNITY_ENTITY_ENTITY_HPP_INCLUDED

namespace dommunity::entity {
	class entity {
	public:
		virtual ~entity() noexcept;

	protected:
		entity() noexcept;
		entity(entity const &) noexcept;

		entity &operator=(entity const &) noexcept;
	};
}

#endif // DOMMUNITY_ENTITY_ENTITY_HPP_INCLUDED
